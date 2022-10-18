namespace PassBox.Mobile.Models
{
    //TODO: Перейти на Site
    public class PasswordInfo : EncryptEntity
    {
        public string Data { get; set; }

        public static PasswordInfo Create()
        {
            return new PasswordInfo { Id = NewId() };
        }
    }
}