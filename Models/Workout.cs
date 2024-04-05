namespace Minimal.Models
{
    public class Workout
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Exercise> Exercises { get; set; }

        public class Exercise
        {
            public string Name { get; set; }
            public int Sets { get; set; }
            public int Reps { get; set; }
            public string Duration { get; set; }
        }

    }
}
