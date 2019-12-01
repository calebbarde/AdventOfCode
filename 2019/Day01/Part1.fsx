#load "Day1.fs"

open System
open Day1

IO.File.ReadLines("input/Part1.txt")
 |> Seq.sumBy (Convert.ToInt32 >> FuelNecessary)
 |> printfn "Gas needed: %i"
