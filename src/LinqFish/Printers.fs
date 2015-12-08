namespace LinqFish

[<AutoOpen>]
module Printers =
    open System.Globalization;

    let public GenericPrinter input =
        input |> Seq.iter (fun i -> printfn "%s" (i.ToString()))

    let public BiPrinter bigram =
        bigram |> Seq.iter (fun (a, b) -> printfn "Bigram: %s %s" a b)

    let public TriPrinter trigram =
        trigram |> Seq.iter (fun (a, b, c) -> printfn "Trigram: %s %s %s" a b c)

    let public StemPrinter stems =
        stems |> Array.iter (fun f -> printfn "Stem: %s" f)

    let public ClausePrinter clauses =
        for clause in clauses do
            clause |> Seq.iter (fun i -> printfn "%s" (i.ToString()))

    let Locale = CultureInfo.GetCultureInfo("en-US")