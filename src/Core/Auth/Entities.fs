namespace Core.Auth.Entities

type Email = string

type User = {
  name: string
  email: Email
}

type Credentials = {
  email: Email
  password: string
}