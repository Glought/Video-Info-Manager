namespace Video_Info_Manager
{
    public class VideoInfo
    {
        public string Name { get; set; }

        public string Tags { get; set; }

        public string Description { get; set; }


        public override string ToString()
        {
            return Name;
        }

    }
}