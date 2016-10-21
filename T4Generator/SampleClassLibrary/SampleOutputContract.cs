namespace SampleClassLibrary
{
    public class SampleOutputContract
    {
        public int ViewColumnId { get; set; }

        public string Name { get; set; }

        public string FieldName { get; set; }

        public bool IsDefault { get; set; }

        public string Description { get; set; }

        public short MinWidth { get; set; }

        public short Width { get; set; }

        public short? Sequence { get; set; }
    }
}
