module Lib

open System

type Direction = 
    | U of steps : int
    | D of steps : int
    | L of steps : int
    | R of steps : int

let toDirection (instruction : string) = //OK
    let direction = instruction.[0]
    let steps = instruction.[1..]

    match (direction, (Convert.ToInt32 steps)) with
    | ('U', steps) -> U(steps)
    | ('D', steps) -> D(steps)
    | ('R', steps) -> R(steps)
    | ('L', steps) -> L(steps)
    | _ -> failwith "No can do hombre"
