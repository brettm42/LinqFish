namespace LinqFishConsole

open LinqFish

module LinqFishConsole =
    open System
    open System.IO
    open System.Text
    
    //open LinqFish
                
    [<EntryPoint>]
    let main argv = 
        printfn "Enter some text to begin:"
        let input = Console.ReadLine()

//        let result = LinqFish.Chunker.Chunker.GetBigrams(input, ' ')
//        let result2 = LinqFish.Chunker.Chunker.GetTrigrams(input, ' ')
//        printfn "Bigrams:\n%s" <| GetBigrams(input, ' ')
//        printfn "Trigrams:\n%s" <| GetTrigrams(input, ' ')
//        printfn "Selected Bigrams:\n%s" <| Select <| GetBigrams(input, ' ')
//        printfn "Selected Bigrams:\n%s" <| Select <| GetTrigrams(input, ' ')
//        let result = Chunker.GetBigrams(input, ' ')
//        let result2 = Chunker.GetTrigrams(input, ' ')
//        let result3 = Chunker.Select(result)
//        let result4 = Chunker.Select(result2)

//        let matcher =
//            for pair in Chunker.GetBigramsSep(input, ' ') do
//                Chunker.Select pair
//                Stemmer.GetStem pair
//                
        let BiPrinter bigram =
            for (a, b) in bigram do
                printfn "Bigram: %s %s" a b

        let TriPrinter trigram =
            for (a, b, c) in trigram do
                printfn "Trigram: %s %s %s" a b c

        let stemmerBi =
            input
            |> Chunker.GetBigrams
            |> Seq.iter Stemmer.GetStem

        let stemmer = 
            input
            |> Chunker.GetBigrams
            |> BiPrinter
            
        let stemmerTri =
            input
            |> Chunker.GetTrigrams
            |> TriPrinter
            

        let pause = Console.ReadLine()
        0
