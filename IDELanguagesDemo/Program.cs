namespace IDELanguagesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDE ide = new IDE();
            LangC c = new LangC();
            LangCSharp cs = new LangCSharp();
            LangJava java = new LangJava();

            //ide.Java = java;
            //ide.C = c;
            //ide.CSharp = cs;

            ide.Languages.Add(c);
            ide.Languages.Add(cs);
            ide.Languages.Add(java);
            ide.Languages.Add(new TypeScript());
            ide.StartWork();
        }
    }

    public interface ILanguage
    {
        string GetName();
        string GetUnit();
        string GetParadigm();
    }

    class IDE // OCP
    {
        //public LangJava Java { get; set; }
        //public LangCSharp CSharp { get; set; }
        //public LangC C { get; set; }

        public List<ILanguage> Languages { get; set; } = new List<ILanguage>();


        public void StartWork()
        {
            foreach (var language in Languages)
            {
                Console.WriteLine(language.GetName());
                Console.WriteLine(language.GetUnit());
                Console.WriteLine(language.GetParadigm());
                Console.WriteLine("========================");
            }

            //Console.WriteLine(CSharp.GetName());
            //Console.WriteLine(CSharp.GetUnit());
            //Console.WriteLine(CSharp.GetParadigm());
            //Console.WriteLine("========================");
            //Console.WriteLine(C.GetName());
            //Console.WriteLine(C.GetUnit());
            //Console.WriteLine(C.GetParadigm());
        }
    }


    // IS-A
    // Realization - class implements interface
    // Generalization - class extends another class


    abstract class ObjectOriented : ILanguage
    {
        public string GetUnit()
        {
            return "Class";
        }
        public string GetParadigm()
        {
            return "Object Oriented";
        }
        public abstract string GetName();

    }

    class LangJava : ObjectOriented
    {

        public override string GetName()
        {
            return "Java";
        }
    }
    class LangCSharp : ObjectOriented
    {

        public override string GetName()
        {
            return "C Sharp";
        }
    }
    class LangC : ILanguage
    {
        public string GetUnit()
        {
            return "Functions";
        }
        public string GetParadigm()
        {
            return "Procedural Oriented";
        }
        public string GetName()
        {
            return "C Language";
        }
    }

    class TypeScript : ObjectOriented
    {

        public override string GetName()
        {
            return "Type Script";
        }
    }


}
