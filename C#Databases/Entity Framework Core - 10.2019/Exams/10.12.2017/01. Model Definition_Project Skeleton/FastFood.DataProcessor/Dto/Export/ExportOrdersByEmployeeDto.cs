namespace FastFood.DataProcessor.Dto.Export
{
    public class ExportOrdersByEmployeeDto
    {
        public string Customer { get; set; }

        public ExportItemsByOrderDto[] Items { get; set; }

        public decimal TotalPrice { get; set; }
    }
}