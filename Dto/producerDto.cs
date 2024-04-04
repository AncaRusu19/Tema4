namespace WebAPI.Dto
{
    public class producerDto
    {
        public producerDto(string producerName)
        {
            ProducerName = producerName;
        }

        public string ProducerName { get; set; }
    }
}
