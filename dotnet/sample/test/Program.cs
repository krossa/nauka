var list = new List<Test>(){new Test{Id=1}};
Console.WriteLine(list.Select(d=>d.Id).FirstOrDefault());

var t = list.FirstOrDefault() != null ? list.FirstOrDefault().Id : 0;

Console.WriteLine(t);

public class Test
{
    public int Id { get; set; }
}