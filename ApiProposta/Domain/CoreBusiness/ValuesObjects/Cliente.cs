namespace ApiProposta.Domain.CoreBusiness.ValuesObjects
{
    public struct Cliente
    {
        public string CPF { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public DateTime dataNascimento { get; set; }

    }
}
