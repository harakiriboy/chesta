import { Author } from "./Author";

export interface AuthorSearchParams {
    username?: string;
    tags: string[];
    status: string;
    authors: Author[] | null;
}