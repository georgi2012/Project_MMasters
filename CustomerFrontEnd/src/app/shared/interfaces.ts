export interface MonsterReceiveModel {
    name: string,
    description: string,
    attackType: string,
    rarity: string,
    health: number,
    defense: number,
    attack: number,
    range: number,
    speed: number
}

export interface UserInfoModel{
    id:string,
    userName:string,
    email:string
}
