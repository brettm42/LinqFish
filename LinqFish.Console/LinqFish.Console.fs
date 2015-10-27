module LinqFishConsole =
    open System
    open System.Text
    open LinqFish

    let GetBigrams(args : string, separator : char) =
        let arr = args.Split(separator)
        [| for a in 0 .. 1 .. (arr.Length - 2) do
            yield (arr.[a], arr.[a + 1]) |]

    let GetTrigrams(args : string, separator : char) =
        let arr = args.Split(separator)
        [| for a in 0 .. 2 .. (arr.Length - 3) do 
            yield (arr.[a], arr.[a + 1], arr.[a + 2]) |]

            
    let Select(grams : Array) =
        seq { for gram in grams do
            fst gram ->
                if a.Contains("select") then
                    yield a }

    [<EntryPoint>]
    let main argv = 
        printfn "Enter some text to begin:"
        let input = Console.ReadLine()
        printfn "\nInput:\n%s" (input.ToString())

        //let result = LinqFish.Chunker.Chunker.GetBigrams(input, ' ')
        //let result2 = LinqFish.Chunker.Chunker.GetTrigrams(input, ' ')
        
        let result = GetBigrams(input, ' ')
        let result2 = GetTrigrams(input, ' ')
        let result3 = Select(result)
        let result4 = Select(result2)

        printfn "\nResults\n%s" (result.ToString())

        let pause = Console.ReadLine()
        0
