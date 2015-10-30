module LinqFishConsole =
    open System
    open System.IO;
    open System.Text
    open System.Text.RegularExpressions;
    open LinqFish

    let GetBigrams(args : string, separator : char) =
        let arr = args.Split(separator)
        [| for a in 0 .. 1 .. (arr.Length - 2) do
            yield (arr.[a], arr.[a + 1]) |]

    let GetTrigrams(args : string, separator : char) =
        let arr = args.Split(separator)
        [| for a in 0 .. 2 .. (arr.Length - 3) do 
            yield (arr.[a], arr.[a + 1], arr.[a + 2]) |]

    let Select(t1, t2) =
        match t1 with
        | "select" -> printfn "Select! Action: %s" t2
        | "test" -> printfn "Test! Action: %s" t2
        | "filter" -> printfn "Filter! Action: %s" t2
        | _ -> printfn "null"

     let GetStem(v, n) =
        match v with
        | "able" -> printfn "found an affix! %s" v
        | _ -> printfn "No match %s" v

    [<EntryPoint>]
    let main argv = 
        printfn "Enter some text to begin:"
        let input = Console.ReadLine()
        printfn "\nInput:\n%s" (input.ToString())

        //let result = LinqFish.Chunker.Chunker.GetBigrams(input, ' ')
        //let result2 = LinqFish.Chunker.Chunker.GetTrigrams(input, ' ')
//        
//        printfn "Bigrams:\n%s" <| GetBigrams(input, ' ')
//        printfn "Trigrams:\n%s" <| GetTrigrams(input, ' ')
//        printfn "Selected Bigrams:\n%s" <| Select <| GetBigrams(input, ' ')
//        printfn "Selected Bigrams:\n%s" <| Select <| GetTrigrams(input, ' ')
//
//        let result = GetBigrams(input, ' ')
//        let result2 = GetTrigrams(input, ' ')
//        let result3 = Select(result)
//        let result4 = Select(result2)

        let matcher =
            for pair in GetBigrams(input, ' ') do
                Select pair
                GetStem pair

        let pause = Console.ReadLine()
        0
