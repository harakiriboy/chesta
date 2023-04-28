import { configureStore } from '@reduxjs/toolkit';
import { counterSlice } from '../features/Settings/counterSlice';
import { TypedUseSelectorHook, useDispatch, useSelector } from 'react-redux';
import { accountSlice } from '../features/Account/accountSlice';

export const store = configureStore({
    reducer: {
        counter: counterSlice.reducer,
        account: accountSlice.reducer
    }
})

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;