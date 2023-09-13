namespace TermékekÉPÍÁJ
{
    public class AdatÁtvitelTárgy
    {
        public record ProductAÁT(Guid Id,string PName,int PPrice,DateTimeOffset IdőKészítés);
        public record CreateProductAÁT(string PName,int PPrice);
        public record ModifyProductAÁT(string PName, int PPrice);
    }
}
