namespace Core.Auth
open Core.Auth.Entities
open System.Collections.Generic

module Repositories =

  type IUserRepository =
    abstract member Save: User -> User
    abstract member FindByEmail: Email -> option<User>

  let private users: Dictionary<Email, User> = new Dictionary<Email, User>()

  let userRepository = {
    new IUserRepository with
      member this.Save (u: User) =
        users.Add(u.email, u) |> ignore
        u
      member this.FindByEmail (email: Email) =
        match users.ContainsKey email with | true -> Some(users.[email]) | _ -> None
  }