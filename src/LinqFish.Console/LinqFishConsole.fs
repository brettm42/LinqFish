namespace LinqFishConsole

module LinqFishConsole =
    open System
    open System.IO
    open System.Text
    open System.Text.RegularExpressions
    
    open LinqFish

    let GetBigramsSep (args : string, separator : char) =
        let arr = args.Split(separator)
        [| for a in 0 .. 1 .. (arr.Length - 2) do
            yield (arr.[a], arr.[a + 1]) |]

    let GetBigrams (args : string) =
        let arr = args.Split(' ')
        [| for a in 0 .. 1 .. (arr.Length - 2) do
            yield (arr.[a], arr.[a + 1]) |]

    let GetTrigrams (args : string, separator : char) =
        let arr = args.Split(separator)
        [| for a in 0 .. 2 .. (arr.Length - 3) do 
            yield (arr.[a], arr.[a + 1], arr.[a + 2]) |]

    let Select (t, p) =
        match t with
        | "select" -> printfn "Select! Action: %s" p
        | "filter" -> printfn "Filter! Action: %s" p
        | "where" -> printfn "Where! Action: %s" p
        | "take" -> printfn "Take! Action: %s" p
        | _ -> printfn "null"
        
    let GetStem (v, n) =
        match v with
        | "able" -> printfn "found affix, %s" v
        | _ -> printfn "No match %s" v
        
        
    [<EntryPoint>]
    let main argv = 
        printfn "Enter some text to begin:"
        let input = Console.ReadLine()

        //let result = LinqFish.Chunker.Chunker.GetBigrams(input, ' ')
        //let result2 = LinqFish.Chunker.Chunker.GetTrigrams(input, ' ')
        //printfn "Bigrams:\n%s" <| GetBigrams(input, ' ')
        //printfn "Trigrams:\n%s" <| GetTrigrams(input, ' ')
        //printfn "Selected Bigrams:\n%s" <| Select <| GetBigrams(input, ' ')
        //printfn "Selected Bigrams:\n%s" <| Select <| GetTrigrams(input, ' ')
        //let result = GetBigrams(input, ' ')
        //let result2 = GetTrigrams(input, ' ')
        //let result3 = Select(result)
        //let result4 = Select(result2)

        let matcher =
            for pair in GetBigramsSep(input, ' ') do
                Select pair
                GetStem pair

        let stemmer =
            input
            |> GetBigrams
            |> Seq.iter GetStem
            
        let pause = Console.ReadLine()
        0
