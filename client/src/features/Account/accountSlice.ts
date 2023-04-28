import { createAsyncThunk, createSlice, isAnyOf } from "@reduxjs/toolkit";
import { User } from "../../models/User";
import { FieldValues } from "react-hook-form";
import agent from "../../services/agent";
import { toast } from "react-toastify";

interface AccountState {
    user: User | null;
}

const initialState: AccountState = {
    user: null
}

export const signInUser = createAsyncThunk<User, FieldValues>(
    'account/signInUser',
    async (data, thunkAPI) => {
        try {
            const user = await agent.Account.login(data);
            localStorage.setItem('localUser', JSON.stringify(user));
            return user;
        } catch(error: any)  {
            return thunkAPI.rejectWithValue({error: error.data});
        }
    }
)

export const registerSubscriber = createAsyncThunk<User, FieldValues>(
    'account/registerSubscriber',
    async (data, thunkAPI) => {
        try {
            const user = await agent.Account.registerUser(data);
            localStorage.setItem('localUser', JSON.stringify(user));
            return user;
        } catch(error: any)  {
            return thunkAPI.rejectWithValue({error: error.data});
        }
    }
)

export const registerAuthor = createAsyncThunk<User, FieldValues>(
    'account/registerAuthor',
    async (data, thunkAPI) => {
        try {
            const user = await agent.Account.registerAuthor(data);
            localStorage.setItem('localUser', JSON.stringify(user));
            return user;
        } catch(error: any)  {
            return thunkAPI.rejectWithValue({error: error.data});
        }
    }
)

export const fetchCurrentUser = createAsyncThunk<User>(
    'account/fetchCurrentUser',
    async (_, thunkAPI) => {
        thunkAPI.dispatch(setUser(JSON.parse(localStorage.getItem('localUser')!)));
        try {
            const user = await agent.Account.getCurrentUser();
            localStorage.setItem('localUser', JSON.stringify(user));
            return user;
        } catch(error: any)  {
            return thunkAPI.rejectWithValue({error: error.data});
        }
    },
    {
        condition: () => {
            if (!localStorage.getItem('localUser')) return false;
        }
    }
)

export const accountSlice = createSlice({
    name: 'account',
    initialState,
    reducers: {
        signOut: (state) => {
            state.user = null;
            localStorage.removeItem('localUser');
        },
        setUser: (state, action) => {
            state.user = action.payload;
        }
    },
    extraReducers: (builder => {
        builder.addCase(fetchCurrentUser.rejected, (state) => {
            state.user = null;
            localStorage.removeItem('localUser');
            toast.error('Session expired - please login again');
        });
        builder.addMatcher(isAnyOf(signInUser.fulfilled, fetchCurrentUser.fulfilled), (state, action) => {
            state.user = action.payload;
        });
        builder.addMatcher(isAnyOf(signInUser.rejected), (state, action) => {
            console.log(action.payload);
        })
    })
})

export const {signOut, setUser} = accountSlice.actions;