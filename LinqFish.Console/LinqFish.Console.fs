module Console =
    open System
    open LinqFish
    open Chunker

    [<EntryPoint>]
    let main argv = 
        printfn "Enter some text to begin:"
        let input = Console.ReadLine()
        printfn "\nInput:\n%s" (input.ToString())
        printfn "\nResults\n%s" (LinqFish.Chunker.Chunker.GetBigrams(input).ToString())
        let pause = Console.ReadLine()
        0
