class Producto{
    public int code{get;set;}
    public string product{get;set;}
    public double price{get;set;}
    public Producto(){}
    public Producto(int code,string product,double price){
        this.code=code;
        this.product=product;
        this.price=price;
    }
    public override string ToString()=> string.Format("{0}|{1}|{2}",this.code,this.product,this.price);
}