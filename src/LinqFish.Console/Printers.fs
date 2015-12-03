namespace LinqFish

[<AutoOpen>]
module Printers =
    open System.Globalization;

    let public BiPrinter bigram =
        for (a, b) in bigram do
            printfn "Bigram: %s %s" a b

    let public TriPrinter trigram =
        for (a, b, c) in trigram do
            printfn "Trigram: %s %s %s" a b c

    let public StemPrinter stems =
        stems |> Array.iter (fun f -> printfn "Stem: %s" f)

    let Locale = CultureInfo.GetCultureInfo("en-US")