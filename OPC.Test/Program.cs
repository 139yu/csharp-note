using System.Net;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using OPCAutomation;
using OpcUaHelper;

namespace OPC.Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // CreateOPCUASession(false);
            // var session = await CreateSessionWithCertificate();
            // OPCUABrowser(session);
            // await OPCUAAsyncRead(session);
            await OPCUAHelper();
            // OPCUAWrite(session);
        }

        #region OPC UA Helper

        static async Task OPCUAHelper()
        {
            
            try
            {
                OpcUaClient client = new OpcUaClient();
                client.UserIdentity = new UserIdentity(new AnonymousIdentityToken());
                await client.ConnectServer("opc.tcp://127.0.0.1:49320");
                var value = client.ReadNode<short>("ns=2;s=通道 1/设备 1/标记 2");
                Console.WriteLine(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        #endregion

        #region OPC UA

        static void OPCUAWrite(Session session)
        {
            WriteValueCollection writeValues = new WriteValueCollection();
            var writeValue = new WriteValue();
            writeValue.NodeId = "ns=2;s=通道 1.设备 1.标记 2";
            writeValue.AttributeId = Attributes.Value;
            // 要与设备的类型一致，否则会报错
            writeValue.Value.Value = (ushort)123;
            writeValues.Add(writeValue);
            var responseHeader = session.Write(new RequestHeader(), writeValues, out StatusCodeCollection results,
                out DiagnosticInfoCollection diagnosticInfos);
            foreach (var statusCode in results)
            {
                // 判断是否成功
                Console.WriteLine(StatusCode.IsGood(statusCode));
            }
        }

        static void Subscription(Session session)
        {
            var item = new MonitoredItem()
            {
                StartNodeId = "ns=2;s=模拟器示例.函数.Ramp1",
                AttributeId = Attributes.Value
            };
            item.Notification += ItemOnNotification;
            var subscription = new Subscription(session.DefaultSubscription);
            subscription.AddItem(item);
            session.AddSubscription(subscription);
            subscription.Create();
        }

        static void ItemOnNotification(MonitoredItem monitoreditem, MonitoredItemNotificationEventArgs e)
        {
            MonitoredItemNotification lastValue = (MonitoredItemNotification)monitoreditem.LastValue;
            Console.WriteLine(lastValue.Value);
        }

        private static async Task OPCUAAsyncRead(Session session)
        {
            Console.WriteLine("-----async read-----");
            var ct = CancellationToken.None;
            var valueIds = new ReadValueIdCollection();
            valueIds.Add(new ReadValueId()
            {
                NodeId = new NodeId("Modbus RTU.Test Device.转速", 2),
                AttributeId = Attributes.DisplayName
            });
            valueIds.Add(new ReadValueId()
            {
                NodeId = new NodeId("数据类型示例.8 位设备.R 寄存器.ByteArray", 2),
                AttributeId = Attributes.Value
            });
            valueIds.Add(new ReadValueId()
            {
                NodeId = new NodeId("数据类型示例.8 位设备.R 寄存器.DoubleArray", 2),
                AttributeId = Attributes.Value
            });
            var reqHeader = new RequestHeader();
            // TAP模式，推荐使用
            var res = await session.ReadAsync(reqHeader, 0, TimestampsToReturn.Both, valueIds, CancellationToken.None);
            DataValueCollection results = res.Results;
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            // 传统APM模式，通过回调获取值
            // session.BeginRead(
            //     new RequestHeader(),
            //     0,
            //     TimestampsToReturn.Both,
            //     valueIds,
            //     DoEndRead,
            //     session
            // );
        }

        private static void DoEndRead(IAsyncResult result)
        {
            var session = result.AsyncState as Session;
            var responseHeader = session.EndRead(result, out DataValueCollection results, out var infos);
            foreach (var value in results)
            {
                if (value.WrappedValue.TypeInfo.ValueRank == -1)
                {
                    Console.WriteLine(value);
                }
                else if (value.WrappedValue.TypeInfo.ValueRank == 1)
                {
                    dynamic arr = null;
                    var type = value.WrappedValue.TypeInfo.BuiltInType;
                    if (type == BuiltInType.Byte)
                    {
                        arr = (byte[])(value.WrappedValue.Value);
                    }
                    else if (type == BuiltInType.Int16)
                    {
                        arr = (ushort[])(value.WrappedValue.Value);
                    }
                    else if (type == BuiltInType.Int32)
                    {
                        arr = (int[])(value.WrappedValue.Value);
                    }
                    else if (type == BuiltInType.Double)
                    {
                        arr = (double[])(value.WrappedValue.Value);
                    }

                    if (arr != null)
                    {
                        foreach (var val in arr)
                        {
                            Console.Write($"{val}--");
                        }
                    }
                }
            }
        }

        static void OPCUARead(Session session)
        {
            var req = new RequestHeader();
            var valueIdCollection = new ReadValueIdCollection();
            valueIdCollection.Add(new ReadValueId()
            {
                NodeId = new NodeId("Modbus RTU.Test Device.转速", 2),
                AttributeId = Attributes.Value
            });
            valueIdCollection.Add(new ReadValueId()
            {
                NodeId = new NodeId("数据类型示例.8 位设备.R 寄存器.ByteArray", 2),
                AttributeId = Attributes.Value
            });
            valueIdCollection.Add(new ReadValueId()
            {
                NodeId = new NodeId("数据类型示例.8 位设备.R 寄存器.DoubleArray", 2),
                AttributeId = Attributes.Value
            });
            // maxAge：以毫秒为单位的最大“年龄”。如果设置为0，表示从服务器获取最新值；如果设置一个正数，服务器可能返回缓存的值（如果缓存的数据在指定时间内刷新过）
            var responseHeader = session.Read(
                req, 0,
                TimestampsToReturn.Both, valueIdCollection,
                out DataValueCollection values,
                out DiagnosticInfoCollection diagnosticInfos);
            foreach (var value in values)
            {
                if (value.WrappedValue.TypeInfo.ValueRank == -1)
                {
                    Console.WriteLine(value);
                }
                else if (value.WrappedValue.TypeInfo.ValueRank == 1)
                {
                    dynamic arr = null;
                    var type = value.WrappedValue.TypeInfo.BuiltInType;
                    if (type == BuiltInType.Byte)
                    {
                        arr = (byte[])(value.WrappedValue.Value);
                    }
                    else if (type == BuiltInType.Int16)
                    {
                        arr = (ushort[])(value.WrappedValue.Value);
                    }
                    else if (type == BuiltInType.Int32)
                    {
                        arr = (int[])(value.WrappedValue.Value);
                    }
                    else if (type == BuiltInType.Double)
                    {
                        arr = (double[])(value.WrappedValue.Value);
                    }

                    if (arr != null)
                    {
                        foreach (var val in arr)
                        {
                            Console.Write($"{val}--");
                        }
                    }
                }
            }
        }

        static void OPCUABrowser(Session session)
        {
            var browser = new Browser(session);
            //root节点下固定有这三个节点：Objects、Types、Views
            //这里browser.Browse(ObjectIds.RootFolder)会返回四个节点，因为它的下标是从1开始的
            // var collection = browser.Browse(ObjectIds.ServerStatusDataType_Encoding_DefaultJson);
            // foreach (var item in collection)
            // {
            //     Console.WriteLine(item);
            // }
            var readValue = session.ReadValue(VariableIds.Server_ServerArray);
            Console.WriteLine(readValue);
        }

        static async void CreateOPCUASession(bool anonymous)
        {
            var appDesc = new ApplicationDescription()
            {
                ApplicationName = "Test OPC UA",
                ApplicationType = ApplicationType.Client
            };

            var securityConfig = new SecurityConfiguration()
            {
                RejectSHA1SignedCertificates = false
            };
            var appConfig = new ApplicationConfiguration()
            {
                ApplicationType = appDesc.ApplicationType,
                ApplicationName = appDesc.ApplicationName.Text,
                ClientConfiguration = new ClientConfiguration()
                {
                    DefaultSessionTimeout = 6000
                }
            };
            appConfig.CertificateValidator = new CertificateValidator();
            appConfig.CertificateValidator.CertificateValidation += (sender, args) => { args.Accept = true; };
            // appConfig.Validate(ApplicationType.Client).Wait();
            var endpoint = CoreClientUtils.SelectEndpoint(appConfig, "opc.tcp://127.0.0.1:49320", false);
            var endpointConfig = new ConfiguredEndpoint(null, endpoint, EndpointConfiguration.Create());
            UserIdentity userIdentity = null;
            if (anonymous)
            {
                userIdentity = new UserIdentity(new AnonymousIdentityToken());
            }
            else
            {
                userIdentity = new UserIdentity("OPC UA", "123456");
            }

            Session session = await Session.Create(appConfig, endpointConfig,
                false,
                "nobody",
                6000,
                userIdentity,
                []
            );
            Console.WriteLine($"create session: {session.SessionId}");
        }

        static async Task<Session> CreateSessionWithCertificate()
        {
            string appName = "SoftingOPCClient";
            var appDesc = new ApplicationDescription()
            {
                ApplicationType = ApplicationType.Client,
                ApplicationName = appName,
                ApplicationUri = $"urn:{Dns.GetHostName()}:{appName}"
            };
            // app config
            var appConfig = new ApplicationConfiguration()
            {
                ApplicationName = appName,
                ApplicationType = appDesc.ApplicationType,
                ApplicationUri = appDesc.ApplicationUri,
                ClientConfiguration = new ClientConfiguration()
            };
            var securityConfig = new SecurityConfiguration()
            {
                ApplicationCertificate = new CertificateIdentifier()
                {
                    StoreType = CertificateStoreType.X509Store,
                    StorePath = "CurrentUser\\" + appName,
                    SubjectName = "Softing OPC Client"
                },
                RejectSHA1SignedCertificates = false,
                MinimumCertificateKeySize = 1024,
            };
            appConfig.SecurityConfiguration = securityConfig;
            var certificateValidator = new CertificateValidator();
            certificateValidator.CertificateValidation += (sender, args) => { args.Accept = true; };
            appConfig.CertificateValidator = certificateValidator;
            await appConfig.Validate(ApplicationType.Client);

            var appInstance = new ApplicationInstance()
            {
                ApplicationConfiguration = appConfig
            };
            var state = await appInstance.CheckApplicationInstanceCertificate(true, 1024, 600);

            var endpoint = CoreClientUtils.SelectEndpoint(appConfig, "opc.tcp://127.0.0.1:49320", true);
            var endpointConfig = new ConfiguredEndpoint(null, endpoint, EndpointConfiguration.Create(appConfig));

            return await Session.Create(appConfig, endpointConfig, false, "nobody", 6000, new UserIdentity(), []);
        }

        #endregion

        #region OPC DA

        static void StudyOPCDA()
        {
            OPCServer server = new OPCServer();
            // ProgID 服务的唯一标识
            // Node 服务器地址，没有标识服务器地址，就在本机找服务，也可以提供IP或计算机名称
            // 如果不在本机，需要配置DCOM通信环境，两个电脑需要在一个域
            server.Connect("Kepware.KEPServerEX.V6");

            var startTime = server.StartTime.ToLocalTime();
            // 获取指定终端的服务列表
            // var servers = server.GetOPCServers();
            /*OPCBrowser browser = server.CreateBrowser();
            browser.ShowBranches();
            browser.ShowLeafs(true);
            foreach (var tag in browser)
            {
                Console.WriteLine(tag);
            }*/
            // 添加Group与Item
            OPCGroups groups = server.OPCGroups;
            OPCGroup group = groups.Add("test");
            group.UpdateRate = 200;
            group.IsActive = true;
            OPCItems items = group.OPCItems;
            // ItemID：同KEPServerEX Client内显示的ItemID，遍历browser的值
            // ClientHandle：同一个Group内唯一标识
            var item = items.AddItem("Modbus RTU.Test Device.转速", 10);
            // serverHandlers下标从1开始
            Array serverHandlers = new int[2] { 0, item.ServerHandle };
            Array values = new object[1] { 0 };
            Array errors = new string[2] { null, null };
            //同步读，serverHandlers下标从1开始
            group.SyncRead((short)OPCDataSource.OPCDevice, 1,
                ref serverHandlers, out values, out errors, out object quality, out object time);
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }

            //异步读
            // 必须设置
            group.IsSubscribed = true;
            group.AsyncReadComplete += Group_AsyncReadComplete;
            // group.AsyncRead(1,ref serverHandlers, out errors,1,out int cancelId);
            // 订阅模式，被动接收，服务端值修改就会触发
            // group.DataChange += GroupOnDataChange;

            // 同步写
            /*Array writeValue = new object[2] { 0, 23 };
            group.SyncWrite(1,ref serverHandlers,ref writeValue, out Array err);
            Console.ReadKey();*/
            //针对单个Item读/写
            item.Read((short)OPCDataSource.OPCDevice, out object val, out object q, out object ts);

            // 获取异常
            string errorString = server.GetErrorString(0);
        }

        private static void GroupOnDataChange(int transactionid, int numitems, ref Array clienthandles,
            ref Array itemvalues, ref Array qualities, ref Array timestamps)
        {
            foreach (var itemValue in itemvalues)
            {
                Console.WriteLine(itemValue);
            }
        }

        private static void Group_AsyncReadComplete(int TransactionID, int NumItems, ref Array ClientHandles,
            ref Array ItemValues, ref Array Qualities, ref Array TimeStamps, ref Array Errors)
        {
            foreach (var itemValue in ItemValues)
            {
                Console.WriteLine(itemValue);
            }
        }

        #endregion
    }
}