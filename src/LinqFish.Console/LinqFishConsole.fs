namespace LinqFishConsole

open LinqFish

module LinqFishConsole =
    open System
    open System.IO
    open System.Text
                    
    [<EntryPoint>]
    let main argv = 
        printfn "Enter some text to begin:"
        let input = Console.ReadLine()
        
        let stemmerBi =
            input
            |> Chunker.GetBigrams
            |> Seq.iter Stemmer.GetStem

        let stemmer = 
            input
            |> Chunker.GetBigrams
            |> Printers.BiPrinter

        let stemmer2 =
            input
            |> Chunker.GetBigrams
            |> Seq.iter (fun f -> Stemmer.GetStems f |> Printers.StemPrinter)
            
        let stemmerTri =
            input
            |> Chunker.GetTrigrams
            |> Printers.TriPrinter
            
        let pause = Console.ReadLine()
        0