import axios, { AxiosError, AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { store } from "../context/configureStore";

axios.defaults.baseURL = 'https://localhost:7014/';

const sleep = () => new Promise(resolve => setTimeout(resolve, 3000));

const responseBody = (response: AxiosResponse) => response.data;

axios.interceptors.request.use(config => {
    const token = store.getState().account.user?.token;
    if (token) {
        if(token.includes('Bearer')) {
            config.headers.Authorization = token;
        }
        else {
            config.headers.Authorization = `Bearer ${token}`;
        }
    }
    return config;
})

axios.interceptors.response.use(response => {
    sleep();
    return response;
}, (error: AxiosError) => {
    const {data, status} = error.response as AxiosResponse;
    switch(status) {
        case 400:
            toast.error(data.title);
            break;
        case 401:
            toast.error(data.title);
            break;
        case 500:
            toast.error(data.title);
            break;
        default:
            break;
    }

    return Promise.reject(error.response);
})

const requests = {
    get: (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
    put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
    delete: (url: string) => axios.delete(url).then(responseBody)
};

const Subscription = {
    list: () => requests.get('subscriptions')
}

const Account = {
    login: (values: any) => requests.post('auth/login', values),
    registerUser: (values: any) => requests.post('auth/registerUser', values),
    registerAuthor: (values: any) => requests.post('auth/registerAuthor', values),
    getCurrentUser: () => requests.get('auth/getCurrentUser')
}

const agent = {
    Subscription,
    Account
}

export default agent;