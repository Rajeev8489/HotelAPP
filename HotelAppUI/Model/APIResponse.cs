namespace HotelAppUI.Model
{
    public class APIResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
        public List<string> ErrorMessage { get; set; }

    }
}
