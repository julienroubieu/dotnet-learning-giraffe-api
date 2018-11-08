namespace Core.Auth
open Core.Auth.Entities
open System.Collections.Generic

module Repositories =

  type IUserRepository =
    abstract member Save: User -> User
    abstract member FindByEmail: Email -> option<User>

  let mutable private users: Map<Email, User> = Map.empty

  let userRepository = {
    new IUserRepository with
      member this.Save (u: User) =
        lock users (fun () -> users = users.Add(u.email, u)) |> ignore
        u
      member this.FindByEmail (email: Email) = users.TryFind email
  }