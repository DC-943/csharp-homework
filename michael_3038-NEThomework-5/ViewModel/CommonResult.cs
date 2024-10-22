namespace michael_3038_WebApiHomework.ViewModel
{
    public class CommonResult<T>
    {

        public bool IsSucess { get; set; }

        public string? Message { get; set; }

        public T? Result { get; set; }

        public string? Errors { get; set; }

        public DateTime? Timestamp { get; set; }

    }
}
