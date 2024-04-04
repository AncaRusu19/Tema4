namespace WebAPI.Dto
{
    public class vinylDto
    {
        public vinylDto(string title,  int age, string best_Song)
        {
            Title = title;
            Age = age;
            Best_Song = best_Song;
        }

        public string Title { get; set; }
        public int Age { get; set; }
        public string Best_Song { get; set; }
    }
}
