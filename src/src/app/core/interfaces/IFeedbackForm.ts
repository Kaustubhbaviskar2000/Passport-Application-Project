import { FeedbackStatus } from "../constants/FeedbackStatus";
import { Feedback } from "../constants/Feedback";

export interface IFeedbackForm {
    feedbackId:string;
    userName: string;
    emailAddress: string;
    feedbackType: Feedback;
    feedbackDescription: string;
    feedbackStatus:FeedbackStatus;
    userId:number; 
  }