#load "Day1.fs"

open System
open Day1

let rec fuelWeights weights =
    match weights with
    | [] -> []
    | recent :: _ when FuelNecessary recent <= 0 -> weights
    | recent :: _ -> fuelWeights ((FuelNecessary recent) :: weights)

let weighModule =
    (fun x -> [ x ])
    >> fuelWeights
    >> List.rev
    >> List.tail
    >> List.sum

IO.File.ReadLines("input/Part1.txt")
|> Seq.map Convert.ToInt32
|> List.ofSeq
|> List.sumBy weighModule
|> printfn "Gas needed: %i"