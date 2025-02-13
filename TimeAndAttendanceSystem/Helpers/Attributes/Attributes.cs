namespace TimeAndAttendanceSystem.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayInGridAttribute : Attribute
    {
        public bool ReadOnly { get; }

        public DisplayInGridAttribute(bool readOnly = false)
        {
            ReadOnly = readOnly;
        }
    }
}
