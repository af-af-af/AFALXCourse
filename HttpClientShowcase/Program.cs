using HttpClientShowcase;

Console.WriteLine("Hello, World!");
var serializationDemo = new SerializationDemo();
var jsonStrings = serializationDemo.RunSerialization();
serializationDemo.RunDeserialization(jsonStrings);
