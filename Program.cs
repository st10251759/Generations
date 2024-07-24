namespace LU1_Object_Generations
{//namespace begin
    class Program
    {//class Program begins
        static void Main()
        {//static void Main() begins

            //Objects are typically placed in 3 catergories when created
            //Generation 0: First generation where new objects are allocated
            //Generation 1: Holds objects that have survived at least 1 cycle of the garbage collector
            //Generation 2: Holds objector that have survived multiple cycles of the garbage collector

            //Objects can akso be seen as Short-Lived & Long_Lived
            //Short-Lived: Often associated to Gen 0. Cleared & memory claimed frequently by GC
            //This can be temporary variables, loop variables, objects used within a short scope

            //Long-Lived: Objects that are expected to persist for long durations during the application's execution
            //Often associated with application state/ resources needed to maintained
            //Typically held in Gen1 and Gen2
            //Less frequent checks by garbage collector

            //create short-lived objects & demonstarte Gen 0 Collection
            CreateGenerationObjects();
            Console.WriteLine($"Gen 0 ) has been collected {GC.CollectionCount(0)}times. ");

            //Force Garbage Collection for Gen 0
            GC.Collect(0);
            Console.WriteLine($"Gen 0 ) has been collected {GC.CollectionCount(0)}times. ");

            //Create additional short-lived objects & demonstarte Gen 1 collection
            CreateGenerationObjects();
            Console.WriteLine($"Gen 1 ) has been collected {GC.CollectionCount(0)}times. ");

            //create long-lived objects, typically allocated to Gen 2
            CreateLongLivedObject();
            GC.Collect(2);
            Console.WriteLine($"Gen 2 ) has been collected {GC.CollectionCount(0)}times. ");


        }//static void Main() end
        static void CreateGenerationObjects()
        {//static void CreateGenerationObjects()
            for (int i = 0; i < 1000; i++)
            {//for
                var obj = new byte[1024]; //1kb
                //This method creates 1000 objects for 1kb each will be allocated to Generation 0
            }//for
        }//static void CreateGenerationObjects()
        static void CreateLongLivedObject()
        {
            //create a long lived object of 10MB
            var longLivedObj = new byte[1024 * 1024 * 10];//10MB

        }
    }//class Program ends
}//namespace ends
