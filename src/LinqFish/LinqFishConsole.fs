namespace LinqFishConsole

open LinqFish

module LinqFishConsole =
    open System
    open System.IO
    open System.Text
    
    let main argv = 
        printfn "Enter some text to begin:"
        let input = Console.ReadLine()
        
        let clauser1 =
            Clauser.GetClauses input
            |> Printers.ClausePrinter

        let stemmer1 = 
            input
            |> Chunker.GetBigrams
            |> Printers.BiPrinter
            
        let stemmerBi =
            input
            |> Chunker.GetBigrams
            |> Seq.iter Stemmer.GetStem

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