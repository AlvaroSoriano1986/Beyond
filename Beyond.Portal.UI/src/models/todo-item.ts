import { Progression } from "./progression";

export class TodoItem {
    constructor(
        public id: number,
        public isCompleted: boolean,
        public title?: string,
        public description?: string,
        public category?: string,
        public progressions?: Progression[]
    ) {}
}