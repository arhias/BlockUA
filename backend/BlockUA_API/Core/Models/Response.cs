namespace Core.Models;

public class Response
{
    public int Code { get; set; }
    public string AdditionalMessage { get; set; }

    public object Data { get; set; }

    public Response(int code, string additionalMessage)
    {
        Code = code;
        AdditionalMessage = additionalMessage;
    }

    public Response(int code, string additionalMessage, object data)
    {
        Code = code;
        AdditionalMessage = additionalMessage;
        Data = data;
    }
}