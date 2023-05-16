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
    get: (url: string, params?: URLSearchParams) => axios.get(url, {params}).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
    put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
    delete: (url: string) => axios.delete(url).then(responseBody)
};

const Subscription = {
    list: () => requests.get('chesta/subscriptions'),
    createSubscriptionPlan: (values: any) => requests.post('chesta/subscriptions/plan', values),
    createSubscription: (values: any) => requests.post('chesta/subscriptions', values),
    listPlans: () => requests.get('chesta/subscriptions/plan')
}

const Publication = {
    list: () => requests.get('chesta/publications'),
    listByAuthor: (username: string) => requests.get(`chesta/publications?authorUsername=${username}`),
    createPublication: (values: any) => requests.post('chesta/publications', values)
}

const Account = {
    login: (values: any) => requests.post('chesta/auth/login', values),
    registerUser: (values: any) => requests.post('chesta/auth/registerUser', values),
    registerAuthor: (values: any) => requests.post('chesta/auth/registerAuthor', values),
    getCurrentUser: () => requests.get('chesta/auth/getCurrentUser'),
    getCurrentAuthor: (id: number) => requests.get(`chesta/auth/getCurrentAuthor?id=${id}`),
    getAuthorsByUsername: (params: URLSearchParams) => requests.get('chesta/author/getByUsername', params),
    getAuthorByUsername: (username: string) => requests.get(`chesta/author/getAuthorByUsername?username=${username}`)
}

const agent = {
    Subscription,
    Account,
    Publication
}

export default agent;