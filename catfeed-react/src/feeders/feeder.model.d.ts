import { userDTO } from "../auth/auth.model";

export interface feederDTO {
    id: number;
    type: string;
    foodWeight: number;
    tag: string;
    foodAtATime: number;
    startTime: Date;
    endTime: Date;
    timesCatShouldEat: number;
    interval: Date;
    feedPresence: boolean;
    feederUserId: string;
}

export interface feederCreationDTO {
    type: string;
    foodWeight: number;
    tag: string;
    foodAtATime: number;
    startTime?: Date;
    endTime?: Date;
    timesCatShouldEat: number;
    interval: number;
    feedPresence: boolean;
}