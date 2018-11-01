package com.volund;

import org.springframework.context.annotation.Configuration;
import org.springframework.web.servlet.config.annotation.ViewControllerRegistry;
import org.springframework.web.servlet.config.annotation.ResourceHandlerRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

@Configuration
public class MvcConfig implements WebMvcConfigurer {
	
	@Override
	public void addResourceHandlers(ResourceHandlerRegistry registry)
	{
		 registry.addResourceHandler(
				 "/favicon.png",
				 "/images/**",
	             "/css/**",
	             "/js/**")
	             .addResourceLocations(
	            		 "classpath:/static/",
	            		 "classpath:/static/public/images/",
	            		 "classpath:/static/public/css/",
	            		 "classpath:/static/public/js/");
		 
		 registry.addResourceHandler(
				"admin-images/**",
				"admin-css/**",
				"admin-js/**")
		 		.addResourceLocations(
		 				"classpath:/static/private/images/",
		 				"classpath:/static/private/css",
		 				"classpath:/static/private/js");
	}
	
	@Override
	public void addViewControllers(ViewControllerRegistry registry)
	{
		registry.addViewController("/home").setViewName("home");
	    registry.addViewController("/").setViewName("home");
	    registry.addViewController("/login").setViewName("login");
	}
}
