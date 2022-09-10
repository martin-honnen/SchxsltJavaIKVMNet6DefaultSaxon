using javax.xml.transform.dom;
using javax.xml.transform.stream;
using net.sf.saxon;
using System.Reflection;
using JFile = java.io.File;

Console.WriteLine($"{Environment.Version} {Environment.OSVersion}");

//Console.WriteLine(string.Join(Environment.NewLine, Assembly.Load("schxslt").GetManifestResourceNames()));
//load Schxslt assembly with the necessary Schxslt XSLT files
ikvm.runtime.Startup.addBootClassPathAssembly(Assembly.Load("schxslt"));

var schematron = new name.dmaus.schxslt.Schematron(new StreamSource(new JFile(args[0])), null, new TransformerFactoryImpl());

var result = schematron.validate(new StreamSource(new JFile(args[1])));

Console.WriteLine($"{args[1]} valid against {args[0]}: {result.isValid()}");

if (!result.isValid())
{
    foreach (var valMsg in result.getValidationMessages().toArray())
    {
        Console.WriteLine(valMsg);
    }

    Console.WriteLine("=======");
    Console.WriteLine("Validation report:");

    var identityTransformer = new TransformerFactoryImpl().newTransformer();
    identityTransformer.setOutputProperty("indent", "yes");
    
    identityTransformer.transform(new DOMSource(result.getValidationReport()), new StreamResult(java.lang.System.@out));
}
