namespace Core.Auth
open System
open Core.Auth.Entities

module Services =

  type IAuthenticator =
    abstract member Authenticate: Credentials -> bool

  let laxAuthenticator = {
    new IAuthenticator with 
      member this.Authenticate (credentials: Credentials) = true
  }