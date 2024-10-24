import { Profile } from "./Profile.js"

export class Recipe {
  constructor(data){
    this.id = data.id
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.title = data.title
    this.instructions = data.instructions
    this.imgUrl = data.imgUrl
    this.category = data.category
    this.creatorId = data.creatorId
    this.creator = new Profile(data.creator)
  }
}