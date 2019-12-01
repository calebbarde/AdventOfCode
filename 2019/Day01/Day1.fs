module Day1

open System

let swap f = fun x y -> f y x

let FuelNecessary sleighModule =
    sleighModule
    |> float
    |> (swap (/) 3.0)
    |> floor
    |> Convert.ToInt32
    |> (swap (-) 2)
