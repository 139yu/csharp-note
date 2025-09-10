namespace Nobody.DigitaPlatform.Entities
{
    public class DeviceEntity
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string DeviceNum { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Z { get; set; }
        public string W { get; set; }
        public string H { get; set; }
        public string Rotate { get; set; }
        public string FlowDirection { get; set; }

        public string TypeName { get; set; }

        public List<DevicePropEntity> DeviceProps { get; set; }
        public List<VariableEntity> Vars { get; set; }
        public List<ManualEntity> ManualControls { get; set; }
    }
}