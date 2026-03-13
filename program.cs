using System;

class Producto
{
    private string nombre;
    private string codigo;
    private double precio;
    private int cantidad;

    public Producto(string nombre, string codigo, double precio, int cantidad)
    {
        this.nombre = nombre;
        this.codigo = codigo;
        this.precio = precio;
        this.cantidad = cantidad;
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Codigo
    {
        get { return codigo; }
        set { codigo = value; }
    }

    public double Precio
    {
        get { return precio; }
        set { precio = value; }
    }

    public int Cantidad
    {
        get { return cantidad; }
        set { cantidad = value; }
    }

    public void MostrarProducto()
    {
        Console.WriteLine("Producto: " + nombre);
        Console.WriteLine("Código: " + codigo);
        Console.WriteLine("Precio: " + precio);
        Console.WriteLine("Cantidad: " + cantidad);
    }

    public virtual double CalcularImpuesto()
    {
        return 0;
    }
}

class ProductoElectronico : Producto
{
    private int garantiaMeses;

    public ProductoElectronico(string nombre, string codigo, double precio, int cantidad, int garantiaMeses)
        : base(nombre, codigo, precio, cantidad)
    {
        this.garantiaMeses = garantiaMeses;
    }

    public int GarantiaMeses
    {
        get { return garantiaMeses; }
        set { garantiaMeses = value; }
    }

    public override double CalcularImpuesto()
    {
        return Precio * 0.18;
    }

    public void MostrarElectronico()
    {
        MostrarProducto();
        Console.WriteLine("Garantía: " + garantiaMeses + " meses");
    }
}

class ProductoAlimento : Producto
{
    private string fechaVencimiento;

    public ProductoAlimento(string nombre, string codigo, double precio, int cantidad, string fechaVencimiento)
        : base(nombre, codigo, precio, cantidad)
    {
        this.fechaVencimiento = fechaVencimiento;
    }

    public override double CalcularImpuesto()
    {
        return Precio * 0.08;
    }

    public void MostrarAlimento()
    {
        MostrarProducto();
        Console.WriteLine("Fecha de vencimiento: " + fechaVencimiento);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ProductoElectronico laptop = new ProductoElectronico("Laptop", "P101", 45000, 5, 12);
        ProductoAlimento arroz = new ProductoAlimento("Arroz", "A100", 1000, 20, "10/12/2027");

        Console.WriteLine("== Producto electrónico ==");
        laptop.MostrarElectronico();
        Console.WriteLine("Impuesto: " + laptop.CalcularImpuesto());

        Console.WriteLine();

        Console.WriteLine("== Producto alimento ==");
        arroz.MostrarAlimento();
        Console.WriteLine("Impuesto: " + arroz.CalcularImpuesto());
    }
}
