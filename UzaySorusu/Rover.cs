namespace Quiz
{
    public class Rover
    {
        public int Id { get; set; }

        public Rover(int id)
        {
            Id = id;
        }

        public Location CurrentLocation { get; set; }
    }
}