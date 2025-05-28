namespace Api.Domain.Models;

public class NullableUpdatePayload<T>
{
    public T? Value {get;set;}
}