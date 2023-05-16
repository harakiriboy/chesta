import { createAsyncThunk, createSlice, isAnyOf } from "@reduxjs/toolkit";
import { User } from "../../models/User";
import { FieldValues } from "react-hook-form";
import agent from "../../services/agent";
import { toast } from "react-toastify";
import { Author } from "../../models/Author";
import { RootState } from "../../context/configureStore";
import { AuthorSearchParams } from "../../models/AuthorSearchParams";

interface AccountState {
    user: User | null;
    authorsLoaded: boolean;
    authorSearchParams: AuthorSearchParams;
}

const initialState: AccountState = {
    user: null,
    authorsLoaded: false,
    authorSearchParams: initParams()
}

function getAxiosParams(AuthorSearchParams: AuthorSearchParams) {
    const params = new URLSearchParams();
    if (AuthorSearchParams.username) params.append('username', AuthorSearchParams.username);
    if (AuthorSearchParams.tags?.length > 0) params.append('tags', AuthorSearchParams.tags.toString());
    return params;
}

function initParams() {
    return {
        status: 'idle',
        authors: null,
        tags: []
    }
}

export const fetchAuthors = createAsyncThunk<Author[], void, {state: RootState}>(
    'account/fetchAuthors',
    async (_, thunkAPI) => {
        const username = getAxiosParams(thunkAPI.getState().account.authorSearchParams);
        try {
            var authors = await agent.Account.getAuthorsByUsername(username);
            return authors;
        }
        catch (error) {
            console.log(error);
        }
    }
)

export const signInUser = createAsyncThunk<User, FieldValues>(
    'account/signInUser',
    async (data, thunkAPI) => {
        try {
            const user: User = await agent.Account.login(data);
            localStorage.setItem('localUser', JSON.stringify(user));
            if (user.role === "author") {
                const author = await agent.Account.getCurrentAuthor(user.id);
                localStorage.setItem('localAuthor', author);
            }
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
            localStorage.removeItem('localAuthor');
        },
        setUser: (state, action) => {
            state.user = action.payload;
        },
        setAuthorSearch: (state, action) => {
            state.authorsLoaded = false;
            state.authorSearchParams = {...state.authorSearchParams, ...action.payload};
        },
        resetAuthorSearch: (state) => {
            state.authorSearchParams = initParams();
        }
    },
    extraReducers: (builder => {
        builder.addCase(fetchCurrentUser.rejected, (state) => {
            state.user = null;
            localStorage.removeItem('localUser');
            toast.error('Session expired - please login again');
        });
        builder.addCase(fetchAuthors.pending, (state) => {
            state.authorSearchParams.status = 'pendingFetchProducts';
        });
        builder.addCase(fetchAuthors.fulfilled, (state, action) => {
            state.authorSearchParams.authors = action.payload;
            state.authorSearchParams.status = 'idle';
            state.authorsLoaded = true;
        });
        builder.addCase(fetchAuthors.rejected, (state, action) => {
            console.log(action.payload);
            state.authorSearchParams.status = 'idle';
        });
        builder.addMatcher(isAnyOf(signInUser.fulfilled, fetchCurrentUser.fulfilled), (state, action) => {
            state.user = action.payload;
        });
        builder.addMatcher(isAnyOf(signInUser.rejected), (state, action) => {
            console.log(action.payload);
        });
    })
})

export const {signOut, setUser, setAuthorSearch, resetAuthorSearch} = accountSlice.actions;