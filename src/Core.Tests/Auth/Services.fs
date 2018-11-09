module Core.Auth.Services

open System
open Xunit
open Core.Auth.Entities
open Core.Auth.Services

[<Fact>]
let ``laxUserRepository should authenticate if password is "password"`` () =
    let credentials = [
        { email = "yo@gmail.com"; password = "password" }
        { email = "yo2@gmail.com"; password = "password" }
        { email = "bla@gmail.com"; password = "password" }
    ]
    let assertAuthenticate cred =
        Assert.True(laxAuthenticator.Authenticate cred)
    List.iter assertAuthenticate credentials
