import { createSlice } from "@reduxjs/toolkit";
import { User } from "../../models/User";

interface PublicationState {
    user: User | null;
}

const initialState: PublicationState = {
    user: null
}

export const publicationSlice = createSlice({
    name: 'publication',
    initialState,
    reducers: {
        createPublication: (state, action) => {

        },
        editPublication: (state, action) => {
            
        }
    }
})