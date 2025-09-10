using csLTDMC;
using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeiSai3800Demo
{
    public class Motion
    {
        //成功
        // 1 ERR_UNKNOWN 未知错误
        // 2 ERR_PARAERR 参数错误
        // 3 ERR_TIMEOUT 操作超时
        // 4 ERR_CONTROLLERBUSY 控制卡状态忙
        // 6 ERR_CONTILINE 连续插补错误
        // 8 ERR_CANNOT_CONNECTETH 无法连接错误
        // 9 MOTION_ERR_HANDLEERR 卡号错误，可能由于函数参
        // 数中的卡号或轴号超出范围产
        // 生，比如有两张卡分别为 0 号和
        // 1 号卡，当轴号为 8 时根据计算
        // 应该为 2 号卡，此时就会产生错
        // 误。
        // 10 ERR_SENDERR
        // 数据传输错误，
        // 请检查 PCI 槽位是否松动
        // 12 ERR_FIRMWAREERR 固件文件错误
        // 14 ERR_FIRMWAR_MISMATCH 固件不匹配
        // 20 ERR_FIRMWARE_INVALID_PARA_ERR 固件参数错误
        // 22 ERR_FIRMWARE_STATE_ERR 固件当前状态不允许操作
        // 24 ERR_FIRMWARE_CARD_NOT_SUPPORT 不支持的功能
        // 1967 旧密码输入错误
        // 1968
        // 旧密码验证次数超限，不能
        // 继续验证
        // 1969 拒绝写入新密码
        private Dictionary<short, string> ErrorCode = new Dictionary<short, string>()
        {
            { 1, "未知错误" },
            { 2, "参数错误" },
            { 3, "操作超时" },
            { 4, "控制卡状态忙" },
            { 6, "连续插补错误" },
            { 8, "无法连接错误" },
            { 9, "卡号错误，可能由于函数参数中的卡号或轴号超出范围产" },
            { 10, "数据传输错误，请检查 PCI 槽位是否松动" },
            { 12, "固件文件错误" },
            { 14, "固件不匹配" },
            { 20, "固件参数错误" },
            { 22, "固件当前状态不允许操作" },
            { 24, "不支持的功能" },
            { 1967, "旧密码输入错误" },
            { 1968, "旧密码验证次数超限，不能继续验证" },
            { 1969, "拒绝写入新密码" },
        };

        private ushort _cardId = 0;
        private uint _cardType = 0;
        public bool InitStatus { get; set; } = false;

        /// <summary>
        /// 初始化轴卡，获取卡id，卡类型
        /// 设置轴位置
        /// </summary>
        /// <returns></returns>
        public Result InitCard()
        {
            try
            {
                short res = LTDMC.dmc_board_init();
                if (res == 0) throw new Exception("没有找到控制卡，或者控制卡异常");
                else if (res <= 0) throw new Exception($"有2张或两张以上硬件卡号相同：{Math.Abs(res) - 1}");
                else if (res > 8) throw new Exception("未知错误");
                ushort cardNum = 0;
                uint[] cardTypeList = new uint[8];
                ushort[] cardIdList = new ushort[8];

                res = LTDMC.dmc_get_CardInfList(ref cardNum, cardTypeList, cardIdList);
                if (res != 0) throw new Exception(ErrorCode[res]);
                _cardId = cardIdList[0];
                _cardType = Convert.ToUInt32(cardTypeList[0].ToString(), 16);

                for (ushort i = 0; i < 3; i++)
                {
                    //轴归零
                    LTDMC.dmc_set_position(_cardId, i, 0);
                }
            }
            catch (Exception ex)
            {
                return Result.Fail(-1, ex.Message);
            }

            InitStatus = true;
            return Result.Ok();
        }

        public Result CloseCard()
        {
            if (InitStatus) return Result.Ok();
            short res = LTDMC.dmc_board_close();
            if (res != 0)
            {
                return Result.Fail(res, ErrorCode[res]);
            }

            return Result.Ok();
        }

        /// <summary>
        /// 设置轴运动参数，包括起始速度，加速度，减速度，最大速度等
        /// </summary>
        /// <param name="axis">轴编号</param>
        /// <param name="startSpeed">起始速度</param>
        /// <param name="maxSpeed">运行速度</param>
        /// <param name="stopSpeed">停止速度</param>
        /// <param name="incTime">加速时间</param>
        /// <param name="sTime">s段时间</param>
        /// <param name="decTime">减速时间</param>
        /// <returns></returns>
        public Result SetMoveParameters(ushort axis,
            double startSpeed, double maxSpeed, double stopSpeed, double incTime, double sTime, double decTime)
        {
            try
            {
                //单轴运动速度曲线设置函数
                short res = LTDMC.dmc_set_profile(_cardId,
                    axis,
                    startSpeed,
                    maxSpeed,
                    incTime, incTime, stopSpeed);
                if (res != 0) throw new Exception(ErrorCode[res]);
                //设置单轴速度曲线 S 段参数值
                res = LTDMC.dmc_set_s_profile(_cardId, axis, 0, sTime);
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }

            return Result.Ok();
        }

        /// <summary>
        /// 单轴点位运动
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="direction">方向，0：负方向，1：正方向</param>
        /// <returns></returns>
        public Result VMove(ushort axis, ushort direction)
        {
            if (!IsMoving(axis))
            {
                LTDMC.dmc_vmove(_cardId, axis, direction);
            }

            return Result.Ok();
        }

        /// <summary>
        /// 点位运动
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="dist">目标位置</param>
        /// <param name="posiMode">运动模式，0：相对坐标模式，1：绝对坐标模式</param>
        /// <returns></returns>
        public Result PMove(ushort axis, int dist, ushort posiMode)
        {
            var res = LTDMC.dmc_pmove(_cardId, axis, dist, posiMode);
            if (res != 0)
            {
                return Result.Fail(ErrorCode[res]);
            }

            return Result.Ok();
        }

        public Result WaitStop(ushort axis)
        {
            var result = StopAxis(axis, 0);
            if (!result.Status) return result;
            bool moveFlag = false;
            do
            {
                moveFlag = IsMoving(axis);
            } while (!moveFlag);

            return Result.Ok();
        }

        /// <summary>
        /// 判断轴是否在运动
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        public bool IsMoving(ushort axis)
        {
            //0：指定轴正在运行，1：指定轴已停止
            if (InitStatus)
            {
                short res = LTDMC.dmc_check_done(_cardId, axis);
                return res == 0;
            }

            return false;
        }

        /// <summary>
        /// 获取当前轴的实际速度
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        public double GetCurrentSpeed(ushort axis)
        {
            return LTDMC.dmc_read_current_speed(_cardId, axis);
        }

        /// <summary>
        /// 读取指令脉冲位置
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        public int GetPosition(ushort axis)
        {
            int position = LTDMC.dmc_get_position(_cardId, axis);
            return position;
        }

        /// <summary>
        /// 读取正在运动的目标位置
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        public int GetCurrentPosition(ushort axis)
        {
            if (IsMoving(axis))
            {
                return LTDMC.dmc_get_target_position(_cardId, axis);
            }

            return 0;
        }

        /// <summary>
        /// 指定轴停止运动
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="mode">制动方式，0：减速停止，1：紧急停止</param>
        /// <returns></returns>
        public Result StopAxis(ushort axis, ushort mode)
        {
            if (IsMoving(axis))
            {
                //0：急停，1：减速停止
                short res = LTDMC.dmc_stop(_cardId, axis, mode);
                if (res != 0) return Result.Fail(res, ErrorCode[res]);
            }

            return Result.Ok();
        }

        /// <summary>
        /// 设置指令脉冲位置
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <param name="position">指令脉冲位置</param>
        /// <returns></returns>
        public Result SetAxisPosition(ushort axis, int position)
        {
            var res = LTDMC.dmc_set_position(_cardId, axis, position);
            if (res != 0)
            {
                return Result.Fail(res, ErrorCode[res]);
            }

            return Result.Ok();
        }

        /// <summary>
        /// 设置指定轴编码器脉冲计数器值
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="encoderValue"></param>
        /// <returns></returns>
        public Result SetEncoder(ushort axis, int encoderValue)
        {
            var res = LTDMC.dmc_set_encoder(_cardId, axis, encoderValue);
            if (res != 0)
            {
                return Result.Fail(res, ErrorCode[res]);
            }

            return Result.Ok();
        }

        /// <summary>
        /// 设置指定轴当前位置为零
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        public Result SetOrigin(ushort axis)
        {
            var result = SetAxisPosition(axis, 0);
            if (result.Status)
            {
                result = SetEncoder(axis, 0);
            }

            return result;
        }

        /// <summary>
        /// 设置 EL 限位信号
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="enable">EL 信号的使能状态：0：正负限位禁止 1：正负限位允许 2：正限位禁止、负限位允许 3：正限位允许、负限位禁止</param>
        /// <param name="logic">0：正负限位低电平有效 1：正负限位高电平有效 2：正限位低有效，负限位高有效 3：正限位高有效，负限位低有效</param>
        /// <param name="mode">0：正负限位立即停止 1：正负限位减速停止 2：正限位立即停止，负限位减速停止 3：正限位减速停止，负限位立即停止</param>
        /// <returns></returns>
        public Result SetElMode(ushort axis, ushort enable, ushort logic, ushort mode)
        {
            var res = LTDMC.dmc_set_el_mode(_cardId, axis, enable, logic, mode);
            if (res != 0)
            {
                return Result.Fail(res, ErrorCode[res]);
            }

            return Result.Ok();
        }

        public uint CheckAxisIoStatus(ushort axis)
        {
            uint status = LTDMC.dmc_axis_io_status(_cardId, axis);
            return status;
        }

        /// <summary>
        /// 设置插补速度
        /// </summary>
        /// <param name="crd"></param>
        /// <param name="maxVel"></param>
        /// <param name="tacc"></param>
        /// <returns></returns>
        public Result SetVectorProfileMulticoor(ushort crd, double maxVel, double tacc)
        {
            var res = LTDMC.dmc_set_vector_profile_multicoor(_cardId, crd, 0, maxVel, tacc, 0, 0);
            if (res != 0)
            {
                return Result.Fail(res, ErrorCode[res]);
            }

            return Result.Ok();
        }

        /// <summary>
        /// 直线插补运动
        /// </summary>
        /// <param name="crd">指定控制卡上的坐标系号；取值范围：0~1</param>
        /// <param name="axisNum">插补轴数</param>
        /// <param name="axisList">插补轴列表</param>
        /// <param name="distList">插补轴目标位置列表</param>
        /// <param name="posiMode">运动模式</param>
        /// <returns></returns>
        public Result LineMulticoor(ushort crd, ushort axisNum, ushort[] axisList, int[] distList, ushort posiMode)
        {
            var res = LTDMC.dmc_line_multicoor(_cardId, crd, axisNum, axisList, distList, posiMode);
            if (res != 0)
            {
                return Result.Fail(res, ErrorCode[res]);
            }

            return Result.Ok();
        }

        /// <summary>
        /// 停止坐标系内所有轴的运动
        /// </summary>
        /// <param name="crd"></param>
        /// <param name="stopMode"></param>
        /// <returns></returns>
        public Result StopAllAxis(ushort crd, ushort stopMode)
        {
            var res = LTDMC.dmc_stop_multicoor(_cardId, crd, stopMode);
            if (res != 0)
            {
                return Result.Fail(res, ErrorCode[res]);
            }

            return Result.Ok();
        }

        /// <summary>
        /// 两轴圆弧插补运动，圆心位置+终点位置
        /// </summary>
        /// <param name="crd"></param>
        /// <param name="axisList"></param>
        /// <param name="targetPos">终点坐标</param>
        /// <param name="cenPos">圆心坐标</param>
        /// <param name="arcDir">圆弧方向</param>
        /// <param name="posiMode">运动模式</param>
        /// <returns></returns>
        public Result ArcMoveMulticoor(ushort crd, ushort[] axisList, int[] targetPos, int[] cenPos, ushort arcDir,
            ushort posiMode)
        {
            var res = LTDMC.dmc_arc_move_multicoor(_cardId, crd,
                axisList,
                targetPos,
                cenPos, arcDir,
                posiMode);
            if (res != 0)
            {
                return Result.Fail(res, ErrorCode[res]);
            }

            return Result.Ok();
        }
        /// <summary>
        /// 设置 ORG 原点信号
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="orgLogic"></param>
        /// <returns></returns>
        public Result SetHomePinLogic(ushort axis, ushort orgLogic)
        {
            var res = LTDMC.dmc_set_home_pin_logic(_cardId, axis, orgLogic, 0);
            if (res != 0)
            {
                return Result.Fail(res, ErrorCode[res]);
            }

            return Result.Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="homeDir">回零方向，0：负向，1：正向</param>
        /// <param name="velMode">回零速度模式，0：startSpeed速度运行；1：runSpeed/maxSpeed速度运行</param>
        /// <param name="mode">回零模式</param>
        /// <returns></returns>
        public Result SetHomeMode(ushort axis,ushort homeDir,ushort velMode,ushort mode)
        {
            var res = LTDMC.dmc_set_homemode(_cardId, axis, homeDir, velMode,mode,0);
            if (res != 0)
            {
                return Result.Fail(res, ErrorCode[res]);
            }

            return Result.Ok();
        }
        /// <summary>
        /// 设置回零偏移量及清零模式
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="enable">清零模式，0：不清零，1：回零完成后清零，再偏移；2：回零以及偏移完成后清零</param>
        /// <param name="position">偏移量</param>
        /// <returns></returns>
        public Result SetHomePosition(ushort axis,ushort enable,double position)
        {
            var res = LTDMC.dmc_set_home_position(_cardId, axis,enable, position);
            if (res != 0)
            {
                return Result.Fail(res, ErrorCode[res]);
            }
            return Result.Ok();
        }

        public Result HomeMove(ushort axis)
        {
            var res = LTDMC.dmc_home_move(_cardId, axis);
            if (res != 0)
            {
                return Result.Fail(res, ErrorCode[res]);
            }
            return Result.Ok();
        }
    }
}