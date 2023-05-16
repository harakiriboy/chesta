import { User } from "./User";

export interface Author {
    id: number;
    authorUsername: string;
    stripeAccountId: string;
    plans: [];
    payments: [];
    userId: number;
    user: User;
    publications: [];
    tag: string;
}